import React from "react";
import { InputText } from "primereact/inputtext";
import "../../styles/globals.scss";
import { BuildInputText } from "@/@types/components";

export default function InputTypeText({
  state,
  setState,
  label,
  required
}: BuildInputText) {
  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "80%" }}>
        <label htmlFor="username" style={{ fontWeight: "500" }}>
          {label}
        </label>
        <InputText
          value={state}
          onChange={(e) => setState(e.target.value)}
          id={`input_${label}`}
          required={required}
        />
      </div>
    </div>
  );
}