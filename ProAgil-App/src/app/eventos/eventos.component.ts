import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  constructor(public httpClientService: HttpClient) { }

  eventos: any = [
    {
      EventoId: 1,
      Tema: 'Angular',
      Local: 'Belo Horizonte'
    },
    {
      EventoId: 2,
      Tema: 'Angular2',
      Local: 'Belo Horizonte'
    },
    {
      EventoId: 3,
      Tema: 'Angular3',
      Local: 'Belo Horizonte'
    }
  ];

  ngOnInit(): void {
  }

  getEvents() {
    this.httpClientService.get("http://localhost:5000/api/values")
  }

}
