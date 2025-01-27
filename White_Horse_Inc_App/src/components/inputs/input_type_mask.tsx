import React from "react";
import "../../styles/globals.scss";
import { BuildMaskInput } from "@/@types/components";
import { InputMask } from "primereact/inputmask";

export default function InputTypeMask({ state, setState, label, mask }: BuildMaskInput) {
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
          value={state ?? ""}
          onChange={(e) => setState(e.target.value ?? "")}
        />
      </div>
    </div>
  );
}