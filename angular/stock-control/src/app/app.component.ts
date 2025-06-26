import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PrimeNG } from 'primeng/config';

@Component({
  selector: 'app-root',
  imports: [RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'stock-control';

  constructor(private primeng: PrimeNG) {}

  ngOnInit() {
    this.primeng.setConfig({
      ripple: true
    });
  }

}
