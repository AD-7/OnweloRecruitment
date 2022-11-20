import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Candidate } from '../_models/candidate';
import { CandidatesService } from '../_services/candidates.service';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit {
  candidates$: Observable<Candidate[]> | undefined;
  model: any  = {};

  constructor(private candidateService: CandidatesService) { }

  ngOnInit(): void {
    this.candidates$ = this.candidateService.getCandidates();
  }

addCandidate(addForm: NgForm){
  if(this.model.name != undefined)
 this.candidateService.addCandidate(this.model.name).subscribe();
 addForm.reset();
}
}
