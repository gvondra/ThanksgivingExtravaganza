import { Injectable } from '@angular/core';
import { FoodMenu } from '../models/food-menu';
import { MockFoodMenu } from '../models/mock-food-menu';
@Injectable({
  providedIn: 'root'
})
export class FoodMenuService {

  constructor() { }

  getAll(): Promise<Array<FoodMenu>> {
    return Promise.resolve(MockFoodMenu);
  }

  get(id: number): Promise<FoodMenu> {
    return Promise.resolve(MockFoodMenu[0]);
  }

  delete(id: number): Promise<any> {
    return Promise.resolve({});
  }

  create(item: FoodMenu): Promise<FoodMenu> {
    return Promise.resolve(item);
  }

  update(item: FoodMenu): Promise<FoodMenu> {
    return Promise.resolve(item);
  }
}
