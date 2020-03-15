import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import { Aluno } from '../models/aluno';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {

  public modalRef: BsModalRef;
  public alunoForm: FormGroup;
  public alunoSelecionado: Aluno;
  public titulo = 'Alunos'
  public textSimple: string;

  alunos = [
    { id: 1, nome: 'Marta' , sobrenome: 'Das Virgens', telefone: 332255 },
    { id: 2, nome: 'Paula' , sobrenome: 'De castro', telefone: 43434 },
    { id: 3, nome: 'Laura' , sobrenome: 'Manuela', telefone: 3777255 },
    { id: 4, nome: 'Luiza' , sobrenome: 'Souza', telefone: 111255 },
    { id: 5, nome: 'Lucas' , sobrenome: 'Santos', telefone: 32498 },
    { id: 6, nome: 'Pedro' , sobrenome: 'Paulo', telefone: 330055 },
    { id: 7, nome: 'Paulo' , sobrenome: 'Silva', telefone: 11111 },
  ];

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder, private modalService: BsModalService) { 
    this.criarForm();
  }

  ngOnInit() {
  }

  criarForm() {
    this.alunoForm = this.fb.group({
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required],
    });
  }

  alunoSubmit() {
    console.log(this.alunoForm.value);
  }

  alunoSelect(aluno: Aluno) {
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno); // manda para view os dados 
  }

  voltar() {
    this.alunoSelecionado = null;
  }
}
