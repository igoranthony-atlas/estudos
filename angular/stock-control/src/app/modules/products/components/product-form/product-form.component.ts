import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { lastValueFrom } from 'rxjs';
import { ProductEvent } from '../../../../models/enums/products/ProductEvent';
import { GetCategoriesResponse } from '../../../../models/interfaces/categories/response/GetCategoriesResponse';
import { EventAction } from '../../../../models/interfaces/products/event/EventAction';
import { EditProductRequest } from '../../../../models/interfaces/products/request/EditProductRequest';
import { GetAllProductResponse } from '../../../../models/interfaces/products/response/GetAllProductResponse';
import { CategoriesService } from '../../../../services/categories/categories.service';
import { ProductService } from '../../../../services/product/product.service';
import { ToastService } from '../../../../services/toast/toast.service';
import { ProductDataTranferService } from '../../../../shared/services/productDataTranfer.service';

@Component({
  selector: 'app-product-form',
  standalone: false,
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit {
  public categoriesList: GetCategoriesResponse[] = [];
  public productForm!: FormGroup;
  public editProductForm!: FormGroup;
  public saleProductForm!: FormGroup;
  public productSelectedDatas!: GetAllProductResponse;
  public productsDatas: GetAllProductResponse[] = [];
  public selectedCategory: { name: string, code: string }[] = [];
  public renderDropdown = false;
  public productAction!: {
    event: EventAction,
    productDatas: Array<GetAllProductResponse>
  }
  public addProductAction = ProductEvent.ADD_PRODUCT_EVENT;
  public editProductAction = ProductEvent.EDIT_PRODUCT_EVENT;
  public saleProductAction = ProductEvent.SALE_PRODUCT_EVENT;

  constructor(
    private categoriesService: CategoriesService,
    private productService: ProductService,
    private toastService: ToastService,
    private formBuilder: FormBuilder,
    private router: Router,
    public ref: DynamicDialogConfig,
    public productDataTransferService: ProductDataTranferService,
    public refDialog: DynamicDialogRef,
  ) { }

  ngOnInit() {
    this.productAction = this.ref.data;
    this.startForm();
    
    if (this.productAction?.event?.action === this.saleProductAction && this.productAction?.productDatas) {
      this.getProductDatas();
    }
    this.getAllCategories();
    this.renderDropdown = true;
  }

  startForm() {
    this.productForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required],
      category_id: ['', Validators.required],
      amount: [0, Validators.required]
    });
    this.editProductForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required],
      amount: [0, Validators.required],
      category_id: ['', Validators.required]
    });
    this.saleProductForm = this.formBuilder.group({
      amount: [0, Validators.required],
      product_id: ['', Validators.required]
    });
  }

  async getAllCategories(): Promise<void> {
    await lastValueFrom(this.categoriesService.getAllCategories())
      .then((response: GetCategoriesResponse[]) => {

        this.categoriesList = response;
        if (this.productAction?.event?.action === this.editProductAction && this.productAction?.productDatas) {
          this.getProductSelectedDatas(this.productAction?.event?.id as string);
        }
      })
      .catch((error) => {
        console.error('Error fetching categories:', error);
        this.toastService.showError('Erro ao buscar categorias.');
      });
  }
  async handleSubmitAddProduct(): Promise<void> {
    if (this.productForm.valid) {
      const productData = this.productForm.value;
      await lastValueFrom(this.productService.createProduct(productData))
        .then((response) => {
          console.log('Product created successfully:', response);
          this.productForm.reset();
          this.refDialog.close(true);
          this.toastService.showSuccess('Produto criado com sucesso.');
        })
        .catch((error) => {
          console.error('Error creating product:', error);
          this.toastService.showError('Erro ao criar produto.');
        });
    }
  }
  async handleSubmitEditProduct(): Promise<void> {
    if (this.editProductForm.valid && this.productAction.event.id) {
      const requestEditProduct: EditProductRequest = {
        name: this.editProductForm.value.name,
        description: this.editProductForm.value.description,
        price: this.editProductForm.value.price,
        amount: this.editProductForm.value.amount,
        product_id: this.productAction.event.id,
        category_id: this.editProductForm.value.category_id

      }
      await lastValueFrom(this.productService.editProduct(requestEditProduct))
        .then(() => {
          this.editProductForm.reset();
          this.refDialog.close(true);
          this.toastService.showSuccess('Produto editado com sucesso.');
        })
        .catch((error) => {
          console.error('Error editing product:', error);
          this.toastService.showError('Erro ao editar produto.');
        });
    }
  }
  getProductSelectedDatas(productId: string): void {
    const allProducts = this.productAction?.productDatas;
    if (allProducts && allProducts.length > 0) {
      const selectedProduct = allProducts.find(product => product.id === productId);
      if (selectedProduct) {
        this.productSelectedDatas = selectedProduct;
        this.editProductForm.setValue({
          name: selectedProduct.name,
          description: selectedProduct.description,
          price: selectedProduct.price,
          amount: selectedProduct.amount,
          category_id: selectedProduct.category.id
        })
      }
    }
  }
  async getProductDatas() {
    lastValueFrom(this.productService.getAllProducts())
      .then((response) => {
        this.productsDatas = response;
        this.productsDatas && this.productDataTransferService.setProductsDatas(this.productsDatas);
      })
      .catch((error) => {
        console.error('Error fetching product data:', error);
        this.toastService.showError('Erro ao buscar dados do produto.');
      });
  }
  async handleSubmitSaleProduct(): Promise<void> {
    if (this.saleProductForm.valid) {
      const requestData = {
        amount: this.saleProductForm.value.amount,
        product_id: this.saleProductForm.value.product_id
      };
      await lastValueFrom(this.productService.saleProduct(requestData))
        .then((response) => {
          this.saleProductForm.reset();
          this.refDialog.close(true);
          this.toastService.showSuccess('Produto vendido com sucesso.');
        })
        .catch((error) => {
          console.error('Error selling product:', error);
          this.toastService.showError('Erro ao vender produto.');
        });
    }
  }
}
