import React from "react";
import "../../styles/globals.scss";
import { BuildMaskInput } from "@/@types/components";
import { InputMask } from "primereact/inputmask";

export default function InputTypeMask(Prop: BuildMaskInput) {
  const handleChange = (e: any) => {
    const rawValue = e.target.value.replace(/\D/g, "");

    const validationMap = {
      rg: (v: string) => v.length >= 8,
      cpf: (v: string) => v.length === 11,
      telefone: (v: string) => v.length === 11,
    };

    const fieldType = Prop.label.toLowerCase() as keyof typeof validationMap;

    if (validationMap[fieldType]?.(rawValue)) {
      Prop.setState(rawValue);
    }
  };

  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
        <label htmlFor="defaultForm" style={{ fontWeight: "500" }}>
          {Prop.label}
        </label>
        <InputMask
          id={`input_mask_${Prop.label}`}
          mask={Prop.mask}
          key={Prop.state}
          placeholder={Prop.mask}
          value={Prop.state}
          onChange={handleChange}
          required={Prop.required}
          invalid={Prop.invalid}
        />
      </div>
    </div>
  );
}