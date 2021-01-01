import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
    'p { max-width: 900px; }'
  ]
})
export class HomeComponent implements OnInit {

  year: number = null;

  constructor() { }

  ngOnInit() {
    let d = new Date();
    this.year = d.getFullYear();
  }

}
