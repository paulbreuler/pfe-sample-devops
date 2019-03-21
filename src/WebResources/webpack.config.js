const path = require('path');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');

module.exports = {
    optimization: {
        minimizer: [new UglifyJsPlugin({
            cache: './src/common/cache/index.ts',
        })]
    },
    entry: {
        Common: './src/common/index.ts',
        Forms: './src/Forms/index.ts',
        Ribbons: './src/Ribbons/index.ts'
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js']
    },
    output: {
        libraryTarget: 'umd',
        library: ['PFE', '[name]'],
        filename: 'pfe_[name].min.js',        
        path: path.resolve(__dirname, 'dist')
    }
};