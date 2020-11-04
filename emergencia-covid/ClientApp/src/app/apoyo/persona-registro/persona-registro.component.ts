import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';


@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {

  formRegistro: FormGroup;
  submitted = false;
  persona: Persona;

  constructor(
    private personaService: PersonaService,private formBuilder: FormBuilder) { }
 

  ngOnInit(): void {
    this.formRegistro = this.formBuilder.group({
      inputIdentificacion : ['',Validators.required],
      inputNombre : ['',Validators.required],
      inputApellido : ['',Validators.required],
      inputSexo : ['',[Validators.required]],
      inputEdad : [0,Validators.required],
      inputDepartamento : ['',Validators.required],
      inputCiudad : ['',Validators.required],
      inputValorApoyo : [0,Validators.required],
      inputModalidadApoyo : ['',Validators.required],
      inputFechaRegistro : ['']
    });
    
    this.persona = new Persona();
  }

  onSubmit(){
    this.submitted = true;
    if(this.formRegistro.invalid){
      return;
    }
    this.add();
  }
  get control() {
    return this.formRegistro.controls;
  }

  add(){
    this.personaService.post(this.persona).subscribe((p)=> {
      if(p != null)
      {
        alert('Persona creada!');
        this.persona = p;
      }
      alert('Persona existente');
    });
  }

  onReset() {
    this.submitted = false;
    this.formRegistro.reset();
  }
  

}
