"use client";
import FormPadrao from "@/components/form_padrao/form";
import "../../styles/globals.scss";
import "./cadastro.scss";

export default function Cadastro(){
    return (
      <div className="conteinerCadastro">
        <form action="" className="formCadastro flexStart">
          <h1>Cadastro:</h1>
          <FormPadrao />
        </form>
      </div>
    );
}