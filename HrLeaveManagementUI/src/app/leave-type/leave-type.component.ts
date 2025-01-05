import { Component, inject } from '@angular/core';
import {Services} from '../Proxies/proxy'

@Component({
  selector: 'app-leave-type',
  templateUrl: './leave-type.component.html',
  styleUrl: './leave-type.component.css'
})
export class LeaveTypeComponent {
  constructor(private apiService: Services){

  }

  ngOnInit(){
   this.getAllLeaveType();  
  }

  getAllLeaveType(){
    this.apiService.leaveTypeGET().subscribe((data)=>{
      debugger;
        console.log(data)

    });
  }
}
