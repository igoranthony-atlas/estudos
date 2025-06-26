import { CommonModule } from '@angular/common';
import { Component, ViewEncapsulation } from '@angular/core';
import { HeaderComponent } from "./components/header/header.component";
import { TodCardComponent } from "./components/tod-card/tod-card.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HeaderComponent, TodCardComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  title = 'todo-list-16';
}
