import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class TransactionService {

  private apiUrl = 'http://localhost:5106/api';

  constructor(private http: HttpClient) { }

  getData(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Transaction`);
  }
  getAllTransactions(skipNumber:number,pageSize:number): Observable<any> {  
    return this.http.get(this.apiUrl+'/Transaction/page?pageSize='+pageSize+'&skipNumber=' + skipNumber);      
   }  
   getTotalDataCount(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Transaction/count`);
  }
}
