import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  year: number = null;

  constructor() { }

  ngOnInit() {
    let d = new Date();
    console.log(d);
    this.year = d.getFullYear();
  }

}
