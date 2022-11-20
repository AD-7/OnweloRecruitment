import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Candidate } from '../_models/candidate';
import { VoteDto } from '../_models/VoteDto';
import { Voter } from '../_models/voter';
import { CandidatesService } from '../_services/candidates.service';
import { VotersService } from '../_services/voters.service';
import { VotingService } from '../_services/voting.service';

@Component({
  selector: 'app-voting',
  templateUrl: './voting.component.html',
  styleUrls: ['./voting.component.css']
})
export class VotingComponent implements OnInit {
  voters$: Observable<Voter[]> | undefined;
  candidates$: Observable<Candidate[]> | undefined;
  model: VoteDto = {voterId : -1, candidateId : -1};
  
  constructor(private votingService: VotingService, private candidatesService: CandidatesService, private votersService: VotersService) { }

  ngOnInit(): void {
    this.voters$ = this.votersService.getVotersNoVoted(true);
    this.candidates$ = this.candidatesService.getCandidates();
  }


  vote(form: NgForm){
    this.votingService.vote(this.model);
    this.votersService.updateVoters(this.model.voterId);
    this.resetModel();
  }
  

  resetModel(){
    this.model = {voterId : -1, candidateId : -1}
  }

}
