import React from "react";
import "../../styles/globals.scss";
import { BuildInputCep } from "@/@types/components";
import { InputMask } from "primereact/inputmask";
import { Endereco, UserInformations } from "@/@types/req";
import PostRequest from "@/routes/post_request";

export default function InputCep({state, setState, label ,required, mask}: BuildInputCep) {
  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "80%" }}>
        <label htmlFor="username" style={{ fontWeight: "500" }}>
          {label}
        </label>
        <InputMask
          id={`input_mask_${label}`}
          mask={mask}
          placeholder={mask}
          value={state.endereco.cep ?? ""}
          onChange={(e) => {
            GetFullAddress(e.target.value ?? "", setState);
          }}
          required={required}
        />
      </div>
    </div>
  );
}

async function GetFullAddress(cep: string, setState:  React.Dispatch<React.SetStateAction<UserInformations>>){
  cep = cep.replace("_","").replace("-", "")
  
  if(cep.length == 8){
    var response: any = await PostRequest(cep);

    if (!response.erro) {
      var enderecoCompleto: Endereco = {
        rua: response.logradouro,
        cep: response.cep,
        bairro: response.bairro,
        cidade: response.localidade,
        numero: 0,
      };

      setState((prevState) => ({
        ...prevState,
        endereco: enderecoCompleto,
      }));
    }
  }
}
