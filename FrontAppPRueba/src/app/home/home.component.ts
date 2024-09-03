import { Component } from '@angular/core';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  data: any[] = [];

  constructor(private apiService:ApiService){}

  ngOnInit():void{
    this.llenarData();
  } 
  
  llenarData () {
    this.apiService.getData().subscribe(data =>{
      this.data = data;
      console.log(this.data);
    })
      

  }

}
