"use client"; // Error boundaries must be Client Components

import { useEffect } from "react";
import '../styles/globals.scss';
import { Button } from "primereact/button";

export default function Error({
  error,
  reset,
}: {
  error: Error & { digest?: string };
  reset: () => void;
}) {
  useEffect(() => {
    console.error(error);
  }, [error]);

  return (
    <div className="flexColumn">
      <h2>Something went wrong!</h2>

      <Button
        label="Tentar Novamente"
        severity="warning"
        outlined
        type="button"
        onClick={() => reset()}
      />
    </div>
  );
}
