import React from "react";
import { InputText } from "primereact/inputtext";
import "../../styles/globals.scss";
import { BuildInputText } from "@/@types/components";

export default function InputTypeText(Prop: BuildInputText) {
  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
        <label htmlFor="defaultForm" style={{ fontWeight: "500" }}>
          {Prop.label}
        </label>
        <InputText
          id={`input_${Prop.label}`}
          value={Prop.state}
          onChange={(e) => Prop.setState(e.target.value)}
          required={Prop.required}
          invalid={Prop.invalid}
        />
      </div>
    </div>
  );
}