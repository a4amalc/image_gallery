import { Component, Inject } from '@angular/core';
import { trigger, style, state, animate, transition } from '@angular/animations';
import { HttpClient } from '../../../node_modules/@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  animations: [
    trigger('openClose', [
      state('true', style({ height: '580px' })),
      state('false', style({ height: '250px' })),
      transition('false <=> true', animate(350))
    ]),
    trigger('childanimate', [
      state('true', style({ height: '350px' })),
      state('false', style({ height: '0px' })),
      transition('false <=> true', animate(350))
    ])
  ],
})
export class HomeComponent {
  images: any=[]

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //Getting image list from API. This should be done through services. for this coding test I am not creating service
    http.get<any>(baseUrl + 'api/Gallery/GetImageList').subscribe(result => {
      if (result.length >= 0) {
        this.images = result;
      }
    }, error => console.error(error));
  }

//Changing image show/hide values so that styles will be automatically reflected in ui with the help of two way data binding
  expandImage(index) {
    for (let i = 0; i < this.images.length; i++) {
      if (i !== index) {
        this.images[i].hide = true;
      }
    }
    this.images[index].hide = !this.images[index].hide;
  }
}
