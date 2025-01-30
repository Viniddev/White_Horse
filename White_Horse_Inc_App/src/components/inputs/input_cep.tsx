import React from "react";
import "../../styles/globals.scss";
import { BuildInputCep } from "@/@types/components";
import { InputMask } from "primereact/inputmask";
import { GetFullAddress } from "@/validators/get_full_address";

export default function InputCep({state, setState, label ,required, mask}: BuildInputCep) {
  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
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


