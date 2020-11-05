import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { IHotBev } from '../interfaces/ihot-bev';
import { HotBevService } from '../services/hot-bev.service';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-hot-bev',
  templateUrl: './hot-bev.component.html',
  styleUrls: ['./hot-bev.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class HotBevComponent implements OnInit {

  hotBevs: IHotBev[];
  dataSource;
  displayedColumns: string[] = [
    'name', 'brand', 'type'
  ];
  expandedElement: IHotBev | null;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<any>;

  constructor(private bevService: HotBevService) { }

  async ngOnInit() {
    this.hotBevs = await this.bevService.getBevs();
    this.dataSource = this.hotBevs;
    this.dataSource.sort = this.sort;
  }

  async delete(id: number) {
    this.bevService.deleteBev(id);
    this.hotBevs = await this.bevService.getBevs();
    this.dataSource = new MatTableDataSource(this.hotBevs);
    // this almost works, but only when you click delete a second time
    this.table.renderRows();
  }
}
