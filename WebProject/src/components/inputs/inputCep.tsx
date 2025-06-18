import React from "react";
import "../../styles/globals.scss";
import { BuildInputCep } from "@/@types/components";
import { InputMask } from "primereact/inputmask";
import { GetFullAddress } from "@/validators/getFullAddress";

export default function InputCep(Prop: BuildInputCep) {
  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
        <label htmlFor="username" style={{ fontWeight: "500" }}>
          {Prop.label}
        </label>
        <InputMask
          id={`input_mask_${Prop.label}`}
          mask={Prop.mask}
          placeholder={Prop.mask}
          value={Prop.state.address.cep ?? ""}
          onChange={(e) => {
            GetFullAddress(e.target.value ?? "", Prop.setState);
          }}
          required={Prop.required}
          invalid={Prop.invalid}
        />
      </div>
    </div>
  );
}


