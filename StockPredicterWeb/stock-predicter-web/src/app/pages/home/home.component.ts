import { Component, OnInit } from '@angular/core';
import { StockApiService } from '../../../services/stock-api.service';
import Stock from '../../DTO/stock';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  stocks: Stock[] = [];

  constructor(private stockApiService: StockApiService) { }

  ngOnInit(): void {
    this.stockApiService.getOne().subscribe(value => {
      for(var name of value.stocksNames) {
        this.stocks.push({name: name});
      }
    });
  }
}
