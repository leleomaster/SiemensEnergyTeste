import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-Header',
  templateUrl: './Header.component.html',
  standalone: true,
  imports: [RouterLink, RouterLinkActive], 
  styleUrls: ['./Header.component.css']
})
export class HeaderComponent {}