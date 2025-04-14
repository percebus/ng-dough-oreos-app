import { Component, OnDestroy, OnInit } from '@angular/core';
import {CommonModule} from '@angular/common';
// import {HousingService} from '../housing.service'; // XXX
import {HousingLocationComponent} from '../housing-location/housing-location.component';
import {HousingLocation} from '../housinglocation';
import { Apollo, gql } from 'apollo-angular';
import { Subscription } from 'rxjs';

const QUERY = gql`
query {
  housingLocations {
    id
    name
    city
    state
    photo
  }
}
`;

@Component({
  selector: 'app-home',
  imports: [CommonModule, HousingLocationComponent],
  template: `
    <section>
      <form>
        <input type="text" placeholder="Filter by city" #filter />
        <button class="primary" type="button" (click)="filterResults(filter.value)">Search</button>
      </form>
    </section>
    <section class="results">
      <app-housing-location
        *ngFor="let housingLocation of filteredLocationList"
        [housingLocation]="housingLocation"
      ></app-housing-location>
    </section>
  `,
  styleUrls: ['./home.component.css'],
})

export class HomeComponent implements OnInit, OnDestroy {
  loading: boolean = false;

  housingLocationList: HousingLocation[] = [];
  filteredLocationList: HousingLocation[] = [];

  // XXX
  // housingService: HousingService = inject(HousingService);

  private querySubscription: Subscription = new Subscription();

  constructor(private readonly apollo: Apollo) { }

  ngOnInit() {
    this.querySubscription = this.apollo
      .watchQuery<any>({
        query: QUERY,
      })
      .valueChanges.subscribe(({ data, loading }) => {
        this.loading = loading;
        this.housingLocationList = data.housingLocations;
        this.filteredLocationList = data.housingLocations;
      });
  }

  filterResults(text: string) {
    if (!text) {
      this.filteredLocationList = this.housingLocationList;
      return;
    }

    this.filteredLocationList = this.housingLocationList.filter((housingLocation) =>
      (housingLocation?.city || '')
        .toLowerCase()
        .includes(text.toLowerCase()),
    );
  }

  ngOnDestroy() {
    this.querySubscription.unsubscribe();
  }
}
