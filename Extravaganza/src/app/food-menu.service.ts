import 'rxjs/add/operator/toPromise';
import { Headers, Http, URLSearchParams } from '@angular/http';
import { Injectable } from '@angular/core';
import { FoodMenu } from './food-menu';
@Injectable()
export class FoodMenuService {

  constructor(private http: Http) { }

  getAll(): Promise<Array<FoodMenu>> {
    return this.http.get("api/menu", {
      headers: new Headers({"Authorization": `Bearer ${localStorage.getItem('access_token')}`})
    })
    .toPromise()
    .then(response => response.json() as Array<FoodMenu>)
  }

  get(id: number): Promise<FoodMenu> {
    return this.http.get("api/menu/" + id, {
      headers: new Headers({"Authorization": `Bearer ${localStorage.getItem('access_token')}`})
    })
    .toPromise()
    .then(response => response.json() as FoodMenu)
  }
}
