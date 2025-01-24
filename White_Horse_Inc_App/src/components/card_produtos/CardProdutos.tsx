import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { CardProdutosProps } from "@/@types/components";

export default function CardProdutos({ prop }: CardProdutosProps) {
  const header = (
    <img
      alt="Card"
      src={prop.link}
    />
  );
  const footer = (
    <>
      <Button label="Save" icon="pi pi-check" />
      <Button
        label="Cancel"
        severity="secondary"
        icon="pi pi-times"
        style={{ marginLeft: "0.5em" }}
      />
    </>
  );

  return (
    <div className="card flex justify-content-center">
      <Card
        title={prop.title}
        subTitle={prop.subtitle}
        footer={footer}
        header={header}
        className="md:w-25rem"
        style={{maxHeight:"560px"}}
      >
        <p className="m-0">{prop.description}</p>
      </Card>
    </div>
  );
}
