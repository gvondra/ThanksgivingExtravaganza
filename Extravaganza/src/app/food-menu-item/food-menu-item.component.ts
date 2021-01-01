import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FoodMenu } from '../models/food-menu';
import { FoodMenuService } from '../services/food-menu.service';

@Component({
  selector: 'app-food-menu-item',
  templateUrl: './food-menu-item.component.html',
  styles: [
  ]
})
export class FoodMenuItemComponent implements OnInit {

  item: FoodMenu = null;
  errorMessage: string = null;
  save: any = null;

  constructor(private route: ActivatedRoute, 
    private router: Router,
    private menuService: FoodMenuService) { }

  ngOnInit() {
    this.route.params
    .subscribe(params => {
      this.errorMessage = null;      
      this.item = null;
      if (params['id']){  
        this.save = this.update;
        this.getItem(params['id'], this.menuService);
      } else {
        this.save = this.create;        
        this.createNewItem();
      }
    });
  }

  createNewItem()
  {
    this.menuService.getAll()
    .then(res =>{
      let maxSortOrder: number = 0;
      if (res) {
        for (let i of res){
          if (i.SortOrder > maxSortOrder){
            maxSortOrder = i.SortOrder;
          }
        }
      }
      this.item = new FoodMenu();
      this.item.Title = "New Item";
      this.item.SortOrder = maxSortOrder + 1;
    });
  }

  getItem(id: number, menuService: FoodMenuService){
    menuService.get(id)
    .then(i => this.item = i)
    .catch(err => this.errorMessage = err.statusText);    
  }

  submit(): void {
    this.save(this.item);
  }

  create(item: FoodMenu): void {
    this.menuService.create(item)
    .then(response => {
      this.save = this.update;
      this.item = response;
    })
  }

  update(item: FoodMenu): void {
    this.menuService.update(item)
    .then(response => this.item = response);
  }

  delete(): void {
    this.menuService.delete(this.item.MenuId)
    .then(res => this.router.navigate(["/menu"]));
  }
}
