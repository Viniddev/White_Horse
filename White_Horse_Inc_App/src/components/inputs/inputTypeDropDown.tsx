import React, { useState } from "react";
import { Dropdown, DropdownChangeEvent } from "primereact/dropdown";
import { ListaTopico, Topico } from "@/@types/components";



export default function DropDown(Listas: ListaTopico) {
  const [selectedCity, setSelectedCity] = useState<Topico | null>(null);

  return (
    <div className="card flex justify-content-center FullLine">
      <div className="flex flex-column gap-2" style={{ width: "90%" }}>
        <label htmlFor="username" style={{ fontWeight: "500" }}>
          Tópicos
        </label>
        <Dropdown
          value={selectedCity}
          onChange={(e: DropdownChangeEvent) => setSelectedCity(e.value)}
          options={Listas.list}
          optionLabel="name"
          placeholder="Selecione um topico"
          className="w-full md:w-full"
        />
      </div>
    </div>
  );
}
