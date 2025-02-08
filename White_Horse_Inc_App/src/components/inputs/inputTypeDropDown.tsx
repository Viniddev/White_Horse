import React, { useState } from "react";
import { Dropdown, DropdownChangeEvent } from "primereact/dropdown";
import { TopicOptions, Topico } from "@/@types/components";



export default function DropDown(Topicos: TopicOptions) {

  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
        <label htmlFor="username" style={{ fontWeight: "500" }}>
          Tópicos
        </label>
        <Dropdown
          value={Topicos.state}
          onChange={(e: DropdownChangeEvent) => Topicos.setState(e.value)}
          options={Topicos.list}
          optionLabel="name"
          placeholder="Selecione um topico"
          className="w-full md:w-full"
          invalid={Topicos.invalid}
        />
      </div>
    </div>
  );
}
