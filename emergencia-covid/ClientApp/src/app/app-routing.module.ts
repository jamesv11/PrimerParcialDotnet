import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule, Routes } from '@angular/router';
import { PersonaConsultaComponent } from './apoyo/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './apoyo/persona-registro/persona-registro.component';
import { HomeComponent } from './home/home.component';


const routes: Routes = [

{
  path:'personaConsulta',
  component: PersonaConsultaComponent
},
{
  path:'personaRegistro',
  component: PersonaRegistroComponent
}
,
{
  path:'',
  component: HomeComponent
}

]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
