import {
  Accordion,
  AccordionDetails,
  AccordionSummary,
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Divider,
  Grid,
  Typography,
} from "@mui/material";
import { useState } from "react";
import IconifyIcon from "../icon";
import { useQuery } from "@tanstack/react-query";
import api from "@/axios/useApi";
import { format } from "date-fns";

export const DialogReports = () => {
  const [open, setOpen] = useState(false);
  const queryReports = useQuery(["reports"], async () => {
    return await api.get("/report").then(({ data }) => data);
  });

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };
  if (queryReports.isLoading) return <></>;
  return (
    <>
      <Button
        variant="outlined"
        color="error"
        fullWidth
        startIcon={<IconifyIcon icon={"mdi:report-bar"} />}
        onClick={handleClickOpen}
      >
        Ver Relatorios
      </Button>
      <Dialog open={open} onClose={handleClose} maxWidth={"xl"} fullWidth>
        <DialogTitle color={"white"} textAlign={"center"}>
          <IconifyIcon icon={"line-md:cloud-print-loop"} fontSize={50} />
          <Typography variant="h6">Relatorios do sistema</Typography>
        </DialogTitle>
        <DialogContent>
          {queryReports.data.map((report) => (
            <Accordion>
              <AccordionSummary
                id="panel-header-1"
                aria-controls="panel-content-1"
                expandIcon={
                  <IconifyIcon fontSize="1.25rem" icon="tabler:chevron-down" />
                }
              >
                <Typography>
                  {report.algorithm} |{"  "}
                  {format(new Date(report.dateTime), "dd/MM/yyyy - hh:mm:ss")}
                </Typography>
              </AccordionSummary>
              <AccordionDetails>
                <Typography variant="body1">
                  Descrição: {report.behavior}
                </Typography>
                <Typography variant="body1" mb={3}>
                  Media de tempo: {report.averageTime}
                </Typography>
                {report.results.map((v, k) => (
                  <Accordion>
                    <AccordionSummary
                      id="panel-header-1"
                      aria-controls="panel-content-1"
                      expandIcon={
                        <IconifyIcon
                          fontSize="1.25rem"
                          icon="tabler:chevron-down"
                        />
                      }
                    >
                      <Typography>Relatorio {k + 1}</Typography>
                    </AccordionSummary>
                    <AccordionDetails>
                      <Grid container spacing={2} mb={2}>
                        <Grid item md={4}>
                          <Typography variant="body1">
                            Tempo Gasto: {v.timeSpentMS}
                          </Typography>
                        </Grid>
                        <Grid item md={4}>
                          <Typography variant="body1">
                            Rotas:{" "}
                            {v.transporter.routes.map((rota) => `${rota} | `)}
                          </Typography>
                        </Grid>
                        <Grid item md={4}>
                          <Typography variant="body1">
                            Caminhões: {v.transporter.trucks.length}
                          </Typography>
                        </Grid>
                        <Grid item md={4}>
                          <Typography variant="body1">
                            Soma das rotas: {v.transporter.sumRoutes}
                          </Typography>
                        </Grid>
                        <Grid item md={4}>
                          <Typography variant="body1">
                            Media de rotas por caminhão:{" "}
                            {v.transporter.averageTruckRoutes}
                          </Typography>
                        </Grid>
                        <Grid item md={4}>
                          <Typography variant="body1">
                            Tolerancia: {v.transporter.tolerance}
                          </Typography>
                        </Grid>
                      </Grid>
                      <Box boxShadow={3} borderColor={"white"} border={1} p={2}>
                        <Typography variant="h6" textAlign={"center"}>
                          Distribuição das rotas
                        </Typography>
                        <Divider sx={{ backgroundColor: "white", my: 2 }} />
                        <Grid container spacing={3} justifyContent={"center"}>
                          {v.transporter.trucks?.map((truck, truckK) => (
                            <Grid item md={3}>
                              <Box
                                textAlign={"center"}
                                boxShadow={3}
                                border={1}
                                borderColor={"white"}
                                p={2}
                              >
                                <Typography variant="body1">
                                  Caminhao {truckK + 1}
                                </Typography>
                                <IconifyIcon
                                  icon={"game-icons:truck"}
                                  fontSize={"150"}
                                  color="cyan"
                                />
                                <Typography variant="body2">
                                  Rotas:{" "}
                                  {truck.routes.map((rota) => `${rota} | `)}
                                </Typography>
                                <Typography variant="body2">
                                  Total: {truck.totalRoute}
                                </Typography>
                              </Box>
                            </Grid>
                          ))}
                        </Grid>
                      </Box>
                    </AccordionDetails>
                  </Accordion>
                ))}
              </AccordionDetails>
            </Accordion>
          ))}
        </DialogContent>
        <DialogActions>
          <Button
            variant="outlined"
            color="error"
            startIcon={<IconifyIcon icon={"mdi:close"} />}
            onClick={handleClose}
            fullWidth
          >
            Fechar
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
