"use client";

import api from "@/axios/useApi";
import { DialogGenerateRoutes } from "@/components/dialogGenerateRoutes";
import { DialogReports } from "@/components/dialogReports";
import IconifyIcon from "@/components/icon";
import {
  Button,
  Card,
  CardContent,
  CardHeader,
  Grid,
  List,
  ListItem,
  TextField,
} from "@mui/material";
import { useQuery } from "@tanstack/react-query";

export default function Home() {
  const queryRoutes = useQuery(["rotas"], async () => {
    return await api.get("/routes").then(({ data }) => data);
  });
  if (queryRoutes.isLoading) return <></>;
  return (
    <>
      <Card sx={{ backgroundColor: "transparent", my: 2 }}>
        <CardHeader title="Rotas Geradas" action={<DialogGenerateRoutes />} />
        <CardContent>
          <List
            sx={{
              width: "100%",
              position: "relative",
              overflow: "auto",
              maxHeight: 80,
              border: "1px solid black",
              borderRadius: "5px",
              "& ul": { padding: 0 },
            }}
          >
            {queryRoutes?.data.map((v, k) => (
              <ListItem>
                Rota {k + 1}: {v.map((rota) => `${rota} | `)}
              </ListItem>
            ))}
          </List>
        </CardContent>
      </Card>
      <Card sx={{ backgroundColor: "transparent", my: 2 }}>
        <CardHeader title="Configurações transportadora" />
        <CardContent>
          <Grid container spacing={2}>
            <Grid item md={6}>
              <TextField
                color="primary"
                autoFocus
                id="name"
                label="Quantidade Caminhões"
                type="number"
                fullWidth
                variant="outlined"
              />
            </Grid>
            <Grid item md={6}>
              <TextField
                color="primary"
                autoFocus
                id="name"
                label="Variação do metodo"
                type="number"
                fullWidth
                variant="outlined"
              />
            </Grid>
          </Grid>
        </CardContent>
      </Card>
      <Card sx={{ backgroundColor: "transparent", my: 2 }}>
        <CardHeader title="Metodos de resolução" />
        <CardContent>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6} xl={3}>
              <Button
                variant="outlined"
                color="success"
                fullWidth
                startIcon={
                  <IconifyIcon icon={"tdesign:component-divider-vertical"} />
                }
              >
                Divisão e conquista
              </Button>
            </Grid>
            <Grid item xs={12} sm={6} xl={3}>
              <Button
                variant="outlined"
                color="error"
                fullWidth
                startIcon={<IconifyIcon icon={"icon-park-twotone:data-all"} />}
              >
                Guloso
              </Button>
            </Grid>
            <Grid item xs={12} sm={6} xl={3}>
              <Button
                variant="outlined"
                color="info"
                fullWidth
                startIcon={
                  <IconifyIcon icon={"icon-park-outline:positive-dynamics"} />
                }
              >
                Programação dinamica
              </Button>
            </Grid>
            <Grid item xs={12} sm={6} xl={3}>
              <Button
                variant="outlined"
                color="warning"
                fullWidth
                startIcon={<IconifyIcon icon={"ph:git-diff-thin"} />}
              >
                Backtracking
              </Button>
            </Grid>
          </Grid>
        </CardContent>
      </Card>
      <DialogReports />
    </>
  );
}
