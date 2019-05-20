import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { Expert } from 'src/app/models/expert';
import { ExpertService } from 'src/app/services/expert.service';
import { GetExpertsDto } from 'src/app/dto/get-expert.dto';

@Component({
  selector: 'app-dialog-assign-experts',
  templateUrl: './dialog-assign-experts.component.html',
  styleUrls: ['./dialog-assign-experts.component.scss']
})
export class DialogAssignExpertsComponent implements OnInit {

  assignForm: FormGroup;
  experts: Expert[];
  constructor(
    private expertService: ExpertService
  ) { }

  ngOnInit() {
    this.assignForm = new FormGroup({
      id: new FormControl(null),
      selectedExperts: new FormControl('', {
        validators: [Validators.required]
      })
    });

    this.expertService.getExperts()
      .subscribe((data: GetExpertsDto) => {
        this.experts = data.experts.map(dto => Expert.Create(dto));
        console.log(this.experts);
      });
  }
}
