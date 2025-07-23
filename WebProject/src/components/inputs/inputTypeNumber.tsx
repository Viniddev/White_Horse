import React from "react";
import "../../styles/globals.scss";
import { BuildInputNumber } from "@/@types/components";
import { InputNumber } from "primereact/inputnumber";

export default function InputTypeNumber(Prop: BuildInputNumber) {
  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
        <label htmlFor="defaultForm" className="font-bold block">
          {Prop.label}
        </label>
        <InputNumber
          inputId={`input_${Prop.label}`}
          value={Prop.state ?? 0}
          onValueChange={(e) => Prop.setState(e.value ?? 0)}
          required={Prop.required}
          invalid={Prop.invalid}
        />
      </div>
    </div>
  );
}