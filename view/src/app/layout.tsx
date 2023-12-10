"use client";
import { QueryClientProvider } from "@tanstack/react-query";
import "./globals.css";
import { Box, Container, Typography } from "@mui/material";
import { queryClient } from "../services/reactQuery.service";
import IconifyIcon from "@/components/icon";
export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <QueryClientProvider client={queryClient}>
      <html lang="pt-br">
        <body>
          <Container>
            <Box textAlign={"center"}>
              <IconifyIcon
                icon={"line-md:cloud-braces-loop"}
                fontSize={"70"}
                color="info"
              />
              <Typography variant="h5">Desafio rotas</Typography>
              <Typography variant="body1">
                Sistema criado para distribuir rotas entre caminhões
              </Typography>
            </Box>
            {children}
          </Container>
        </body>
      </html>
    </QueryClientProvider>
  );
}
