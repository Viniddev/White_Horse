import React from "react";
import { Password } from 'primereact/password';
import { BuildInputText } from "@/@types/components";
import "../../styles/globals.scss";

export default function InputTypePassword(Prop: BuildInputText) {
  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
        <label htmlFor="username" style={{ fontWeight: "500" }}>
          {Prop.label}
        </label>
        <Password
          id={`input_${Prop.label}`}
          required={Prop.required}
          value={Prop.state}
          onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
            Prop.setState(e.target.value)
          }
          feedback={false}
          toggleMask
          invalid={Prop.invalid}
          className="w-full"
          pt={{
            iconField: {
              root: {
                style: { width: "100%" },
              },
            },
            input: {
              style: { width: "100%" },
            },
            root: {
              style: { width: "100%" },
            },
          }}
        />
      </div>
    </div>
  );
}