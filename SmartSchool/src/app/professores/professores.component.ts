import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css']
})
export class ProfessoresComponent implements OnInit {

  titulo= 'Professores'
  professores = [
    { id: 1,nome:'João', disciplina: 'Matemática' },
    { id: 2,nome:'Andre', disciplina: 'Física' },
    { id: 3,nome:'Ricardo', disciplina: 'Português' },
    { id: 4,nome:'Luiza', disciplina: 'Inglês' },
    { id: 5,nome:'Alan', disciplina: 'Programação' },
  ];
  constructor() { }

  ngOnInit() {
  }

}
