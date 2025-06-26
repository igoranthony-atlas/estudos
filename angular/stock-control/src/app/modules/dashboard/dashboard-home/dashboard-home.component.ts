import { Component } from '@angular/core';
import { ChartData, ChartOptions } from 'chart.js';
import { Card } from 'primeng/card';
import { ChartModule } from 'primeng/chart';
import { lastValueFrom } from 'rxjs';
import { GetAllProductResponse } from '../../../models/interfaces/products/response/GetAllProductResponse';
import { ProductService } from '../../../services/product/product.service';
import { ToastService } from '../../../services/toast/toast.service';
import { ProductDataTranferService } from '../../../shared/services/productDataTranfer.service';
import { ToolbarNavigationComponent } from '../../../shared/toolbar-navigation/toolbar-navigation.component';

@Component({
  selector: 'app-dashboard-home',
  standalone: true,
  imports: [ToolbarNavigationComponent, Card, ChartModule],
  templateUrl: './dashboard-home.component.html',
  styleUrl: './dashboard-home.component.scss'
})
export class DashboardHomeComponent {
  public productList: Array<GetAllProductResponse> = [];
  public productsChartData!: ChartData;
  public productsChartOptions!: ChartOptions;

  constructor(
    private productsService: ProductService,
    private toast: ToastService,
    private productsDtService: ProductDataTranferService
  ) {}

  ngOnInit(): void {
    this.getAllProducts();
  }

  async getAllProducts() {
    await lastValueFrom(this.productsService.getAllProducts())
      .then((response: Array<GetAllProductResponse>) => {
        this.productList = response;
        console.log('Products fetched successfully:', this.productList);
        this.productsDtService.setProductsDatas(this.productList);
        this.setProductsChartConfig();
      })
      .catch((error) => {
        console.error('Error fetching products:', error);
        this.toast.showError('Erro ao carregar os produtos');
      });
  }

  setProductsChartConfig() {
    if (this.productList.length > 0) {
      const documentStyle = getComputedStyle(document.documentElement);
      
      const surfaceBorder = documentStyle.getPropertyValue('--surface-border');

      this.productsChartData = {
        labels: this.productList.map((product) => product.name),
        datasets: [
          {
            label: 'Quantidade',
            data: this.productList.map((product) => product.amount),
            backgroundColor: '#50c878',
            borderColor: '#50c878',
            hoverBackgroundColor: '#50c878',
            borderWidth: 1
          }
        ]
      };

      this.productsChartOptions = {
        maintainAspectRatio: false,
        aspectRatio: 0.8,
        plugins: {
          legend: {
            labels: {
              color: 'black'
            }
          },
          tooltip: {
            backgroundColor: documentStyle.getPropertyValue('--surface-100'),
            titleColor: 'white',
            bodyColor: 'white',
            borderColor: surfaceBorder,
            borderWidth: 1
          }
        },
        scales: {
          x: {
            ticks: {
              color: 'black',
              font: {
                weight: 500
              }
            },
            grid: {
              color: surfaceBorder
            }
          },
          y: {
            ticks: {
              color: 'black'
            },
            grid: {
              color: surfaceBorder
            }
          }
        }
      };
    }
  }
}
