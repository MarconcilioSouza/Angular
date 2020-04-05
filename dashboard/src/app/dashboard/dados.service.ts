import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable({
  providedIn: 'root'
})
export class DadosService {

    readonly dados = [
      ['Janeiro', 33],
      ['Fevereiro',68],
      ['Março',49],
      ['Abril',100],
      ['Maio',80],
      ['Junho',522]
    ];
  constructor() { }

  /**
   * Retorna um obervable contendo os dados a serem
   * exibidos no grafico
   * @return Observable<any>
   */
  obterDados(): Observable<any> {
    return new Observable(observable => {
        observable.next(this.dados);
        observable.complete();
    });
  }
}
