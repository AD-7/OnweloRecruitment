import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { VoteDto } from '../_models/VoteDto';

@Injectable({
  providedIn: 'root'
})
export class VotingService {
  baseUrl = environment.apiBaseUrl;


  constructor(private http: HttpClient, private toastr: ToastrService) { }

  vote(voteDto: VoteDto){
    this.http.put(this.baseUrl + "voting", voteDto).subscribe( result => {
      if(result){
      this.toastr.success("Vote has been added!", "Success")
      }
    });
  }
  
}
