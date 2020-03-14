import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {

  public alunoSelecionado: string;
  public titulo = 'Alunos'
  alunos = [
    { id: 1, nome: 'Marta' , sobrenome: 'Das Virgens', telefone: 332255 },
    { id: 2, nome: 'Paula' , sobrenome: 'De castro', telefone: 43434 },
    { id: 3, nome: 'Laura' , sobrenome: 'Manuela', telefone: 3777255 },
    { id: 4, nome: 'Luiza' , sobrenome: 'Souza', telefone: 111255 },
    { id: 5, nome: 'Lucas' , sobrenome: 'Santos', telefone: 32498 },
    { id: 6, nome: 'Pedro' , sobrenome: 'Paulo', telefone: 330055 },
    { id: 7, nome: 'Paulo' , sobrenome: 'Silva', telefone: 11111 },
  ];

  alunoSelect(aluno: any) {
    this.alunoSelecionado = aluno.nome;    
  }

  voltar() {
    this.alunoSelecionado = '';
  }
  constructor() { }

  ngOnInit() {
  }

}
