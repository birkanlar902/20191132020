import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ActivatedRoute } from '@angular/router';
import { Kategori } from 'src/app/models/Kategori';
import { Urun } from 'src/app/models/Urun';
import { ApiService } from 'src/app/services/api.service';
import { MyAlertService } from 'src/app/services/myAlert.service';
import { ConfirmDialogComponent } from '../dialogs/confirm-dialog/confirm-dialog.component';
import { GorselyukleDialogComponent } from '../dialogs/gorselyukle-dialog/gorselyukle-dialog.component';
import { UrunDialogComponent } from '../dialogs/urun-dialog/urun-dialog.component';

@Component({
  selector: 'app-kategori-urun',
  templateUrl: './kategori-urun.component.html',
  styleUrls: ['./kategori-urun.component.css'],
})
export class KategoriUrunComponent implements OnInit {
  urunler: Urun[];
  kategori: Kategori;
  katId: number;
  dataSource: any;
  displayedColumns = [
    'urunGorsel',

    'urunAdi',
    'urunStok',
    'urunFiyatSat',

    'urunAciklama',
  ];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public apiServis: ApiService,
    public matDialog: MatDialog,
    public alert: MyAlertService,
    public route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.params.subscribe((p) => {
      console.log(p);
      if (p.katId) {
        this.katId = p.urunKatId;
        this.UrunGetirByKatId();
        this.KategoriById();
      }
    });
  }

  KategoriById() {
    this.apiServis.KategoriById(this.katId).subscribe((d: Kategori) => {
      this.kategori = d;
    });
  }

  UrunGetirByKatId() {
    this.apiServis.UrunListeByKatId(this.katId).subscribe((d: Urun[]) => {
      this.urunler = d;
    });
  }
}
