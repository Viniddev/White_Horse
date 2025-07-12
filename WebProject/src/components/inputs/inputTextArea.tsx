import React from "react";
import "../../styles/globals.scss";
import { BuildInputText } from "@/@types/components";
import { InputTextarea } from "primereact/inputtextarea";

export default function InputTypeTextArea(Prop: BuildInputText) {
  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
        <label htmlFor="username" style={{ fontWeight: "500" }}>
          {Prop.label}
        </label>
        <InputTextarea
          variant="filled"
          id={`input_${Prop.label}`}
          value={Prop.state}
          onChange={(e) => Prop.setState(e.target.value)}
          required={Prop.required}
          invalid={Prop.invalid}
          rows={5}
          cols={30}
        />
      </div>
    </div>
  );
}