import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AdalService } from '../shared/services/adal.service';
import { IConsultants } from '../Interfaces/IConsultants';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  API_URL = environment.userApiKey + 'user/';

  constructor(private httpClient: HttpClient,
    private adalService: AdalService) { }

  GetJobDetails(userId = null): Observable<any> {
    const relativeUrl = userId ? this.API_URL + 'jobsposted/' + userId : this.API_URL + 'jobsposted';
    return this.httpClient.get<any>(relativeUrl);
  }
  GetJobSearchTerms(): Observable<any> {
    return this.httpClient.get<any>(this.API_URL + 'searchstrings');
  }
  GetJobSearchResults(searchTerm, userId): Observable<any> {
    const data = { SearchQuery: searchTerm };
    return this.httpClient.post<any>(this.API_URL + `filter/jobs/${userId}`, data);
  }
  AddOrUpdateJobRole(data: any): Observable<any> {
    return this.httpClient.post<any>(this.API_URL + 'update/job/roles', data);
  }
  SubmitFeedBack(data): Observable<any> {
    return this.httpClient.post<any>(this.API_URL + 'update/job/status', data);
  }
  getLeaderBoard(): Observable<any> {
    return this.httpClient.get<any>(this.API_URL + 'leader/board');
  }
  GetAllConsultants(): Observable<any> {
    return this.httpClient.get<any>(this.API_URL + 'consultants');
  }
  AddOrUpdateConsultant(consultantData: IConsultants): Observable<any> {
    return this.httpClient.post<any>(this.API_URL + 'consultant', consultantData);
  }
  DeleteConsultant(consultantId: number): Observable<any> {
    return this.httpClient.get<any>(this.API_URL + 'consultant/' + consultantId + '/' + this.adalService.userInfo.userName);
  }
  GetAllConsultantsAndJobsForMember(): Observable<any> {
    return this.httpClient.get<any>(this.API_URL + 'all/consultants/jobs/' + this.adalService.userInfo.userName);
  }
  GetSelectedConsultantJobsForMember(consultantIdList: string): Observable<any> {
    const data = { SearchQuery: consultantIdList };
    return this.httpClient.post<any>(this.API_URL + 'consultants/jobs/' + this.adalService.userInfo.userName, data);
  }
}
