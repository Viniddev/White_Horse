import React from "react";
import { Button } from "primereact/button";
import { CardProdutosProps } from "@/@types/components";

import "../../styles/globals.scss"
import "./cardProdutos.scss";
import { Card } from "primereact/card";

export default function CardProdutos({ prop }: CardProdutosProps) {
  const header = (
    <img
      alt="Card"
      src={prop.link}
      style={{maxHeight:"350px"}}
    />
  );

  const footer = (
    <div className="flexRow spaceEvenly">
      <Button
        label="Cancel"
        severity="secondary"
        icon="pi pi-times"
        style={{ marginLeft: "0.5em" }}
      />
      <Button label="Save" icon="pi pi-check" />
    </div>
  );

  //criar meu proprio card, esse ta paioso e generico

  return (
    <div className="card flex justify-content-center sm:w-5 lg:w-auto">
      <Card
        title={prop.title}
        subTitle={prop.subtitle}
        footer={footer}
        header={header}
        className="md:w-25rem"
      >
        <p className="m-0">{prop.description}</p>
      </Card>
    </div>
  );
}
