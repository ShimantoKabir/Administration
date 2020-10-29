export default class HttpHandler {

    static handlePost(callBackFunction, alert, url, data) {

        let CallBackFunction = callBackFunction;
        let Alert = alert;
        let Url = url;
        let Data = data;

        Alert.show({
            title: 'Loading',
            bodyIcon: 'fas fa-spin fa-sync',
            bodyMsg: 'Please wait ... !',
        });

        return axios.post(Url, Data)
            .catch(error => {

                console.log(JSON.stringify(error.message));

                if (error.response.data) {

                    if (error.response.data.message) {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data.message,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    } else if (error.response.data.exception) {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data.exception,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    } else {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    }

                }

            });

    }

    static handlePut(callBackFunction, alert, url, data) {

        let CallBackFunction = callBackFunction;
        let Alert = alert;
        let Url = url;
        let Data = data;

        Alert.show({
            title: 'Loading',
            bodyIcon: 'fas fa-spin fa-sync',
            bodyMsg: 'Please wait ... !',
        });

        return axios.put(Url, Data)
            .catch(error => {

                console.log(JSON.stringify(error));

                if (error.response.data) {

                    if (error.response.data.message) {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data.message,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    } else if (error.response.data.exception) {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data.exception,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    } else {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    }

                }

            });

    }

    static handleGet(callBackFunction, alert, url) {

        let CallBackFunction = callBackFunction;
        let Alert = alert;
        let Url = url;

        Alert.show({
            title: 'Loading',
            bodyIcon: 'fas fa-spin fa-sync',
            bodyMsg: 'Please wait ... !',
        });

        return axios.get(Url)
            .catch(error => {

                console.log(JSON.stringify(error));

                if (error.response.data) {

                    if (error.response.data.message) {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data.message,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    } else if (error.response.data.exception) {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data.exception,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    } else {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    }

                }

            });

    }

    static handleDelete(callBackFunction, alert, url, data) {

        let CallBackFunction = callBackFunction;
        let Alert = alert;
        let Url = url;
        let Data = data;

        Alert.show({
            title: 'Loading',
            bodyIcon: 'fas fa-spin fa-sync',
            bodyMsg: 'Please wait ... !',
        });

        return axios.delete(Url, {data: Data})
            .catch(error => {

                console.log(JSON.stringify(error));

                if (error.response.data) {

                    if (error.response.data.message) {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data.message,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    } else if (error.response.data.exception) {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data.exception,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    } else {

                        Alert.show({
                            title: 'Error',
                            bodyIcon: 'fas fa-exclamation-circle',
                            bodyMsg: error.response.data,
                            onCallBack: CallBackFunction,
                            try: true,
                            code: error.response.status
                        });

                    }

                }

            });

    }

}
