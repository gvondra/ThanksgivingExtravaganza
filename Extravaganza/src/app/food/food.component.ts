import { Component, OnInit } from '@angular/core';
import { FoodMenu } from '../models/food-menu';
import { FoodMenuService } from '../services/food-menu.service';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styles: [
    'a { color: lightyellow; }',
    'p { max-width: 750px; }'
  ]
})
export class FoodComponent implements OnInit {

  menuItems: Array<FoodMenu> = null;

  constructor(private menuService: FoodMenuService) { }

  ngOnInit(): void {
    this.menuService.getAll()
    .then(res => this.menuItems = res);
  }

}
