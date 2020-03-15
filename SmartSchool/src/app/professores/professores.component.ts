import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import { Professor } from '../models/professor';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css']
})
export class ProfessoresComponent implements OnInit {

  public modalRef: BsModalRef;
  professorSelecionado: Professor;
  titulo= 'Professores';

  professores = [
    { id: 1,nome:'João', disciplina: 'Matemática' },
    { id: 2,nome:'Andre', disciplina: 'Física' },
    { id: 3,nome:'Ricardo', disciplina: 'Português' },
    { id: 4,nome:'Luiza', disciplina: 'Inglês' },
    { id: 5,nome:'Alan', disciplina: 'Programação' },
  ];

  professorSelect(prof: Professor) {
    this.professorSelecionado = prof;
  }

  voltar() {
    this.professorSelecionado = null;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private modalService: BsModalService) { }

  ngOnInit() {
  }
}
