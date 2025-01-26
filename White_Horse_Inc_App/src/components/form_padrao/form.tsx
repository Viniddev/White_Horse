import React from "react";
import InputTypeText from "../inputs/input_type_text";
import { Button } from "primereact/button";

export default function FormPadrao(){
    const [teste, setTeste] = React.useState<string>("");
    return(
         <div>
            <div className="formgrid grid">
              <div className="field col-12 lg:col-6">
                <InputTypeText
                  state={teste}
                  setState={setTeste}
                  label={"E-mail"}
                />
              </div>
              <div className="field col-12 lg:col-6">
                <InputTypeText
                  state={teste}
                  setState={setTeste}
                  label={"Telefone"}
                />
              </div>
              <div className="field col-12 lg:col-6">
                <InputTypeText
                  state={teste}
                  setState={setTeste}
                  label={"Cep"}
                />
              </div>
              <div className="field col-12 lg:col-6">
                <InputTypeText
                  state={teste}
                  setState={setTeste}
                  label={"Rua"}
                />
              </div>

              <div className="field col-12 lg:col-6">
                <InputTypeText
                  state={teste}
                  setState={setTeste}
                  label={"Bairro"}
                />
              </div>
              <div className="field col-12 lg:col-6">
                <InputTypeText
                  state={teste}
                  setState={setTeste}
                  label={"Número"}
                />
              </div>

              <div className="field col-12 lg:col-6">
                <InputTypeText
                  state={teste}
                  setState={setTeste}
                  label={"Cidade"}
                />
              </div>

              <div className="field col-12">
                <div className="sessaoBotaoSalvar">
                  <Button label="Atualizar" severity="danger" />
                </div>
              </div>
            </div>
          </div>
    );
}