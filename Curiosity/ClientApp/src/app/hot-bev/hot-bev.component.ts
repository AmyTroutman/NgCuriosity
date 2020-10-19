import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { IHotBev } from '../interfaces/ihot-bev';
import { HotBevService } from '../services/hot-bev.service';

@Component({
  selector: 'app-hot-bev',
  templateUrl: './hot-bev.component.html',
  styleUrls: ['./hot-bev.component.css']
})
export class HotBevComponent implements OnInit {

  hotBevs: IHotBev[];
  dataSource: MatTableDataSource<IHotBev>;
  displayedColumns: string[] = [
    'name', 'brand', 'type', 'subtype', 'mood'
  ];
  @ViewChild(MatSort, {static: true})sort: MatSort;

  constructor(private bevService: HotBevService) { }

  async ngOnInit() {
    this.hotBevs = await this.bevService.getBevs();
    this.dataSource = new MatTableDataSource<IHotBev>(this.hotBevs);
    this.dataSource.sort = this.sort;
  }

}
