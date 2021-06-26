import React, { useState, useEffect } from 'react';
import { Grid, Select, TextField, Button, MenuItem, FormControl } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

export const Calculator = () => {

    const [functions, setFunctions] = useState([]);
    const [selectedFunc, setSelectedFunc] = useState("");
    const [firstValue, setFirstValue] = useState(0);
    const [secondValue, setSecondValue] = useState(0);
    const [calculationResult, setCalculationResult] = useState(0);

    const classes = makeStyles((theme) => ({
        formControl: {
            margin: theme.spacing(1),
            minWidth: 120,
        }
    }));

    useEffect(() => {
        fetch('https://localhost:44351/api/getFunctions')
            .then(res => res.json())
            .then((result) => {
                setFunctions(result);
                setSelectedFunc(result[0].functionName)
            });
    }, []);

    const handleChange = event => {
        setSelectedFunc(event.target.value);
    }

    const handleCalculate = (e) => {

        const date = new Date();

        e.preventDefault();

        let valuesForCalc = {
            date: date,
            typeOfCalculation: selectedFunc,
            input: {
                firstValue: firstValue,
                secondValue: secondValue
            }
               
        }

        let requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(valuesForCalc)
        }

        fetch('https://localhost:44351/api/getCalculation', requestOptions)
            .then(res => res.json())
            .then(data => setCalculationResult(data))
    }

    return (
        <form onSubmit={handleCalculate}>
            <p>Please select a function and enter 2 values to get the probability</p>
            <Grid container>
                <Grid item xs={3}>
                    <FormControl className={classes.formControl}>
                        <p>Function:</p>
                        <Select onChange={handleChange} variant="outlined" value={selectedFunc}>
                        {functions.map((func, index) => {
                            return <MenuItem key={index} value={func.functionName}>{func.functionName}</MenuItem>
                        })}
                        </Select>
                    </FormControl>
                    <FormControl className={classes.formControl}>
                        <TextField label="Value 1" variant="outlined" type="number" margin="normal" onChange={(e) => setFirstValue(e.target.value)} />
                    </FormControl>
                    <FormControl className={classes.formControl}>
                        <TextField label="Value 2" variant="outlined" type="number" margin="normal" onChange={(e) => setSecondValue(e.target.value)}/>
                    </FormControl>
                    <FormControl className={classes.formControl}>
                        <Button type="submit" value="submit" variant="outlined" color="primary">calculate</Button>
                    </FormControl>
                    <FormControl className={classes.formControl}>
                        <TextField label="result" value={calculationResult} variant="outlined" margin="normal" disabled />
                    </FormControl>
                </Grid>
            </Grid>        
        </form>
    )
}