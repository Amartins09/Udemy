var gulp = require('gulp');
var concat = require('gulp-concat');
var uncss = require('gulp-uncss');
var cssmin = require('gulp-cssmin');
var browserSync = require('browser-sync').create();

gulp.task('browser-sync', function(){
    browserSync.init({
        proxy: 'localhost:5000'
    });

    gulp.watch('./Style/*.css', ['css']);
    gulp.watch('./Js/*.js', ['js']);
});

gulp.task('js', function(){
    return gulp.src([
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        './js/**/*.js',
    ])
    .pipe(gulp.dest('./Js/'))
    .pipe(browserSync.stream());
});

gulp.task('css', function(){
    return gulp.src([
        './styles/site.css',
        './node_modules/bootstrap/dist/css/bootstrap.css',
    ])
    .pipe(concat('site.min.css'))
    .pipe(cssmin())
    .pipe(uncss({html: ['Views/**/*.cshtml']}))
    .pipe(gulp.dest('./Styles/css'))
    .pipe(browserSync.stream());
});
