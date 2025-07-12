import React from "react";
import "../../styles/globals.scss";
import { BuildMaskInput } from "@/@types/components";
import { InputMask } from "primereact/inputmask";

export default function InputTypeMask(Prop: BuildMaskInput) {
  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
        <label htmlFor="username" style={{ fontWeight: "500" }}>
          {Prop.label}
        </label>
        <InputMask
          id={`input_mask_${Prop.label}`}
          key={Prop.state}
          mask={Prop.mask}
          placeholder={Prop.mask}
          value={Prop.state ?? ""}
          onChange={(e) => Prop.setState(e.target.value ?? "")}
          required={Prop.required}
          invalid={Prop.invalid}
        />
      </div>
    </div>
  );
}